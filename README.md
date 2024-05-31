# RCWChecker

外部から対象プロセスにアタッチしてメモリ上の RCW 情報を直接可視化する簡単なツールです。

C# で取得した COM オブジェクトは、ランタイム呼び出し可能ラッパー(RCW)と呼ばれるプロキシを介してネイティブな COM の 呼び出しを行います。
すなわち、RCW は COM オブジェクトと対応するオブジェクトです。しかも、実行中のプロセスの外部から RCW を監視できる ClrMD というライブラリがあるらしく、これを使用することで取得した COM オブジェクトの解放状況をリアルタイムで可視化することができるようです。

ClrMD は、プロセスやクラッシュダンプの調査など、.NET Framework/.NET アプリの高度なデバッグ作業に使用するものであって、特に RCW に特化したものではありません。しかし、COM 操作においては扱うオブジェクトの種類や数が限定されることもあり、RCW を可視化するだけでリーク調査などで有効に活用できそうです。

ClrMD
[Microsoft.Diagnostics.Runtime (microsoft/clrmd) | Github](https://github.com/microsoft/clrmd)

RCW についての説明
[.NET での COM 相互運用 | Microsoft Lean](https://docs.microsoft.com/ja-jp/dotnet/standard/native-interop/cominterop)

ClrMD を使用したコード例など
[.NETを使った別プロセスのOfficeの自動化が面倒なはずがない―そう考えていた時期が俺にもありました。 | Qiita](https://qiita.com/mima_ita/items/aa811423d8c4410eca71)

上記サイトに外部プロセスに接続してメモリ上の RCW 情報をダンプするコード例が掲載されています。ただ、コンソールアプリであるため使いづらく、これを GUI アプリに変更し、自分用に少し拡張を加えたものが RCWChecker です。
