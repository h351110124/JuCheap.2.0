###  您可以考虑给作者来个小小的打赏以资鼓励，您的肯定将是我最大的动力


 **Description** 

JuCheap V2.0响应式后台管理系统模板,MVC5+EF6+Bootstrap3搭建了一个通用的后台管理系统的模板，里面使用到的技术包括：MVC,EF,T4模板批量生成,Jquery,jqGrid,Bootstrap,DDD,AutoMapper等

 **Instructions** 

1.框架使用的EF Code First模式，在运行的时候，程序自动帮你初始化数据库、数据表和初始数据.<br/> 
2.配置Web.Config文件里面的数据库连接字符串，就可以直接运行项目. <br/>
3.默认数据库类型是MySql，如需要使用MsSql，请按照web.config 文件中的注释修改.<br/>
4.初始数据放在，JuCheap.Data项目的/Config/Configuration.cs文件里面.<br/>

 **Attentions** 

~~记得将Web.config文件里Form认证里面的domain改成自己的，要不会登录不了~~

<b style="color:#D91E18">~~&lt;forms name="AuthenToken" loginUrl="~/Adm/User/Login" timeout="2880" domain="www.jucheap.com" /&gt;~~</b>

<b>身份认证已由forms认证改成了asp.net identity身份认证,对于登陆认证不再需要做额外的配置。</b>

 **Demo view**

![jucheap](http://git.oschina.net/uploads/images/2016/1109/115238_f6e40415_422345.png "jucheap")

![jucheap](http://git.oschina.net/uploads/images/2016/1109/115304_99754093_422345.png "jucheap")

![jucheap](http://git.oschina.net/uploads/images/2016/1109/122732_191c2c6c_422345.png "jucheap")

![jucheap](http://git.oschina.net/uploads/images/2016/1109/122746_7a14746f_422345.png "jucheap")

![jucheap](http://git.oschina.net/uploads/images/2016/1109/122754_cbf08341_422345.png "jucheap")

![jucheap](http://git.oschina.net/uploads/images/2016/1109/122802_622365f2_422345.png "jucheap")

 **net core 版本**   
最新源代码：https://gitee.com/jucheap/JuCheap.Core  
预览地址：http://core.jucheap.com  