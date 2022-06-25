using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LoveMachine.Core
{
    internal interface IDeviceEvent
    {
        float StartTime { get; }
    }

    internal abstract class LinearPattern
    {
        internal abstract LinearEvent GetNextEvent(float normalizedTime);

        internal struct LinearEvent : IDeviceEvent
        {
            public float StartTime { get; set; }
            public float EndTime { get; set; }
            public float EndPosition { get; set; }
        }
    }

    internal class HiResLinearPattern
    {
        
    }

    internal class LowResLinearPattern : LinearPattern
    {
        private readonly List<LinearEvent> commands;

        public LowResLinearPattern(IList<Sample> samples)
        {
            var wave = new CircularArray<Sample>(samples.OrderBy(s => s.Time).ToArray());
            wave = LowPassFilter.Filter(wave);
            commands = new List<LinearEvent>();
            var localExtremaIndexes = GetLocalExtremaIndexes(wave);
            for (int i = 0; i < localExtremaIndexes.Count; i++)
            {
                int start = localExtremaIndexes[i];
                int end = i < localExtremaIndexes.Count - 1
                    ? localExtremaIndexes[i + 1]
                    : localExtremaIndexes[0] + wave.Length;
                float deltaSum = 0;
                float deltaQuadSum = 0;
                float indexWeightedSum = 0;
                for (int j = start; j < end; j++)
                {
                    float delta = (wave[j + 1].Distance - wave[j - 1].Distance) / 2;
                    float deltaSq = delta * delta;
                    deltaSum += Math.Abs(delta);
                    deltaQuadSum += deltaSq;
                    indexWeightedSum += j * deltaSq;
                }
                float slope = deltaQuadSum / deltaSum;
                int slopeCenter = (int)(indexWeightedSum / deltaQuadSum);
                int length = (int)Math.Abs((wave[end].Distance - wave[start].Distance) / slope);
                int startIndex = slopeCenter - length / 2;
                int endIndex = slopeCenter + length / 2;
                var command = new LinearEvent
                {
                    StartTime = wave[startIndex].Time,
                    EndTime = wave[endIndex].Time,
                    EndPosition = wave[end].Distance
                };
                commands.Add(command);
            }
        }

        internal override LinearEvent GetNextEvent(float normalizedTime) =>
            commands.OrderBy(command => ((command.StartTime - normalizedTime) % 1f + 1f) % 1f)
            .First();

        private static List<int> GetLocalExtremaIndexes(CircularArray<Sample> wave)
        {
            var localExtremaIndexes = new List<int>();
            float nextValue(int startIndex)
            {
                int i = startIndex + 1;
                while (wave[i].Distance == wave[startIndex].Distance)
                {
                    i++;
                }
                return wave[i].Distance;
            }
            for (int i = 0; i < wave.Length; i++)
            {
                float delta = wave[i].Distance - wave[i - 1].Distance;
                if (delta == 0f)
                {
                    continue;
                }
                if (delta * (nextValue(i) - wave[i].Distance) < 0f)
                {
                    localExtremaIndexes.Add(i);
                }
            }
            return localExtremaIndexes;
        }
    }

    internal class LowPassFilter
    {
        internal static CircularArray<Sample> Filter(CircularArray<Sample> input)
        {
            Sample[] output = new Sample[input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                float avg = 0f;
                for (int j = -2; j <= 2; j++)
                {
                    avg += input[i + j].Distance;
                }
                avg /= 5f;
                output[i] = new Sample
                {
                    Bone = input[i].Bone,
                    Time = input[i].Time,
                    Distance = avg
                };
            }
            return new CircularArray<Sample>(output);
        }
    }

    internal struct Sample
    {
        public Bone Bone { get; set; }
        public float Time { get; set; }
        public float Distance { get; set; }
    }

    internal class CircularArray<T>
    {
        private T[] items;

        public CircularArray(T[] items) => this.items = items;

        public int Length => items.Length;

        public T this[int index] => items[(items.Length + (index % items.Length)) % items.Length];
    }
}
