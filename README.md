# WindowsFormApp

## 初期アプリケーション
Visual Studio 上でform application 作成


## SQLServer
gitpod 公式が [Microsoft SQL Server のテンプレート](https://github.com/gitpod-io/template-microsoft-mssql-server)を出していたので、これで代用


接続方法はここを参照 https://zenn.dev/hashito/articles/83d11192de6168
```bash
$ docker exec -it mssql bash 
```

ログインできんわ、やり方が分からん


## DB接続処理の作成
ベースの DbContex^1 を作成する。

claude の生成結果を参考に、GetConnection() を作成

```xml
<configuration>
  <connectionStrings>
    <add name="MyDbContext" 
         providerName="System.Data.SqlClient"
         connectionString="Server=myServerName;Database=myDataBase;User Id=myUsername;Password=myPassword;"/>
  </connectionStrings>
</configuration>
```

```csharp
var connString = ConfigurationManager.ConnectionStrings["MyDbContext"].ConnectionString;
var optionsBuilder = new DbContextOptionsBuilder<MyDbContext>();
var options = optionsBuilder.UseSqlServer(connString).Options;
using (var db = new MyDbContext(options)) 
{
    // DBアクセスコードをここに記述
}
```

app.config から取得した文字列にパスワード等を動的に設定することになったら、[^4]を参考にする

app.config は環境ごとに複数持たせて、切り替える[^3]


パスワードの暗号化は。。。するか検討中^2




* 参考[^1]: [EntityFrameworkのデータファーストとDbContextの接続文字列を動的に変える方法](https://turing.hatenablog.com/entry/2016/07/16/170001)
[^2]: [EntityFrameworkでconfigファイル内の接続文字列をプログラム内で動的に変更させる方法](https://shin21.hatenablog.com/entry/2016/02/05/230000)
[^3]: [App.configをビルドターゲットによって書き換える](https://qiita.com/m2tmk/items/c24e4d0eb30d820dd7b5)
[^4]: [SqlConnectionStringBuilder クラス](https://learn.microsoft.com/ja-jp/dotnet/api/microsoft.data.sqlclient.sqlconnectionstringbuilder?view=sqlclient-dotnet-standard-5.2)
