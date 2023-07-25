# MVVM サンプル

ごく単純なカウントアプリを MVVM で実装したもの。
ロジックと UI を分離し、Model と ViewModel を単体テストすることができるように設計した。

## それぞれのプロジェクト

- MvvmSample : アプリケーション本体のプロジェクト
- MvvmSample.Test : xUnit と moq を使用して簡単なテストコードを書いたプロジェクト

### MvvmSample: シーケンス図

大まかなシーケンス図を示す

![class diagram](out/sequence/sequence.png)

### MvvmSample: クラス図

大まかなクラス図を示す

![class diagram](out/class_diagram/class_diagram.png)
