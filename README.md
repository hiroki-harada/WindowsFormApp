# WindowsFormApp

## �����A�v���P�[�V����
Visual Studio ���form application �쐬


## SQLServer
gitpod ������ [Microsoft SQL Server �̃e���v���[�g](https://github.com/gitpod-io/template-microsoft-mssql-server)���o���Ă����̂ŁA����ő�p


�ڑ����@�͂������Q�� https://zenn.dev/hashito/articles/83d11192de6168
```bash
$ docker exec -it mssql bash 
```

���O�C���ł����A�������������


## DB�ڑ������̍쐬
�x�[�X�� DbContex^1 ���쐬����B

claude �̐������ʂ��Q�l�ɁAGetConnection() ���쐬

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
    // DB�A�N�Z�X�R�[�h�������ɋL�q
}
```

app.config ����擾����������Ƀp�X���[�h���𓮓I�ɐݒ肷�邱�ƂɂȂ�����A[^4]���Q�l�ɂ���

app.config �͊����Ƃɕ����������āA�؂�ւ���[^3]


�p�X���[�h�̈Í����́B�B�B���邩������^2




* �Q�l[^1]: [EntityFramework�̃f�[�^�t�@�[�X�g��DbContext�̐ڑ�������𓮓I�ɕς�����@](https://turing.hatenablog.com/entry/2016/07/16/170001)
[^2]: [EntityFramework��config�t�@�C�����̐ڑ���������v���O�������œ��I�ɕύX��������@](https://shin21.hatenablog.com/entry/2016/02/05/230000)
[^3]: [App.config���r���h�^�[�Q�b�g�ɂ���ď���������](https://qiita.com/m2tmk/items/c24e4d0eb30d820dd7b5)
[^4]: [SqlConnectionStringBuilder �N���X](https://learn.microsoft.com/ja-jp/dotnet/api/microsoft.data.sqlclient.sqlconnectionstringbuilder?view=sqlclient-dotnet-standard-5.2)
