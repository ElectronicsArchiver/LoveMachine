**※このマニュアルは、日本語が母国語ではない人が書いたものです。 文法的な誤りは山ほどあるかもしれません。 このページを編集したいと思う方はプルリクエストを作成して下さい。 よろしくお願いします。**

# BepInEx LoveMachine

LoveMachineは、ゲームエンジンUnityを使った3Dエロゲを連動オナホールやバイブレータに対応できるようにする為のプラグインです。

現在互換性があるゲームは：
* **コイカツ！（VRも）**
* **ハニーセレクト２（VRも）**
* **コイカツ！サンシャイン（VRも）**
* **プレイホーム（VRも）**
* **奉課後輪姦中毒（VRも、[AGHVR](https://github.com/Eusth/AGHVR)で）**
* **Our Apartment**
* **インサルトオーダー（VRも、[IOVR](https://github.com/Eusth/IOVR)で）**
* **カスタムオーダーメイド3D2（VRも）**

LoveMachineは[buttplug](https://buttplug.io/)というオープンソースプロトコルのお陰でいろんなデバイスと繋がることが出来ます。

現在互換性があるデバイスは：
* A10ピストンSA
* [The Handy](https://www.thehandy.com/?ref=saucekebenfield&utm_source=saucekebenfield&utm_medium=affiliate&utm_campaign=The+Handy+Affiliate+program)
* KIIROO KEON
* Xboxゲームパッド（振動）
* [そしてこのリストにあるデバイスほぼすべて](https://iostindex.com/?filter0ButtplugSupport=4)


## インストール

LoveMachineをインストールするための前提条件とそのダウンロードはこちら：
* [Intiface Desktop](https://intiface.com/desktop/) v24以降
* [BepInEx](https://github.com/BepInEx/BepInEx/releases) 5.3以降 （ZIPの内容をそのままゲームフォルダーにドラッグすること）

つぎ、[LoveMachineの最新リリース](https://github.com/Sauceke/BepInEx.LoveMachine/releases)ページで、プラグインをどっちのゲームにインストールしたいかによってLoveMachine_for_Honey_Select_2かLoveMachine_for_KoikatsuというZIPをダウンロードして、その内容をゲームフォルダーにコピーしたらインストールが完成です。

※ゲームフォルダーにBepInExというフォルダーがすでに存在するはずです。 それを気にしないでLoveMachineのZIPにあるBepInExフォルダーも同じゲームフォルダーにコピーすればいいのです。


## 使い方

* Intiface Desktopを開始します。
* Server Status > Start Serverをクリックします。
* 使いたいデバイスを起動してBluetoothモードにします。 必要ならペアリングもします。
* Intifaceをタスクバーに置いてゲームを開始します。
* そうしたらデバイスがゲームのHシーンのアニメーションに合わせて動き出すはずです。

※デバイスは同時に何台でも繋がることが可能です。


## 仕組みの説明・制約

* LoveMachineは女性キャラクターの手、股間、胸、そして口のボーンの動きを分析するためにキャリブレーションをします。
* キャリブレーションは新しいアニメーションがロードされた瞬間に行い、およそ１０フレームが掛かります。 こういう時はアニメーションが一瞬だけグリッチしたように見えます。
* その後、プレーヤーの金玉に一番近いボーンに合わせてLoveMachineがオナホールを電動させます。
* こういう仕組みなのでキャラクターが大きすぎる、あるいは小さすぎる場合は連動が映像に合わないことになる可能性があります。 つまりSliderUnlockerで無茶しない方がいいです。
