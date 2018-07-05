登录注册使用iframe，出于组件化开发考虑，把登录注册弹框做成通用插件，那么就要用到iframe，可能最大的问题是跨域问题，其他也没什么，而且只要你父页面和子页面的顶级域名是一致的，跨域问题也很好解决，两边都设置document.domain就Ok啦。

1. iframe会阻塞主页面的Onload事件；
2. iframe和主页面共享连接池，而浏览器对相同域的连接有限制，所以会影响页面的并行加载。

Single Page Application，没错，iframe确实是最原始的SPA的做法，但是浏览器渲染iframe很多时候会花费很多额外的资源，因此不推荐。
现在SPA都是数据接口化，前端渲染，路由模块来掌控历史记录控制。现在流行做法是直接上AngularJS、knockout、ember.js、avalon.js等框架来做开发，但是如果要学这些框架，前提是有良好的JavaScript基础，否则学习路线会很陡峭。至于你说的换个模式(也就是传统方案)，其实也还好，页面传输通常会做gzip的压缩.


首先要明白iframe的应用场景，iframe并不是不能用，而是不能滥用。
* 在数据提交上iframe相比ajax能够提供更高的稳定性以及兼容度，因此在这方面使用一下无妨；
* 同时iframe的作用是内嵌网页，如果需要引用别的网页做说明，iframe也是必要的。但是，利用内嵌网页的方式引入固定的内容是完全错误地！虽然现在很多开源程序的后台仍在使用这种做法，这不过是开发者偷懒的手段而已，在前台应用中应极力避免这种做法，无论是对用户还是对搜索引擎的友好度这种做法都是极傻。回到问题来，题主你竟然不知道可以通过后端引入公用模块的方式让页面某一区域内容固定！！！将导航栏的内容抽离成一个模板，通过后端引入再和本页的内容拼接输出，这是后端新手都应该懂的常识来的吧←_←使用后端引入的话，每次页面打开导航区和内容区都是一并加载的，实现的效果和你在每个页面都复制一个导航区是一样的。只是在代码上文件被拆分方便管理而已。
* 请不要在意每次都要重新加载导航区，那一点代码产生的带宽资源占用和你页面上的图片以及JQ库比起来算不了什么。题主想的方式是使用ajax读取每个页面的内容并填充到内容区。这么做并无不妥，但是做法也忒蛋疼了点，还不如直接用iframe引用导航栏。ajax是不应该被滥用，在一些交互上使用ajax避免页面整体刷新减少请求量是一种很方便的做法，但是页面切换也用ajax那就是2B做法了。
* 至于高度自适应的问题，可以通过JS来做，在页面ready的时候判断内容区元素的高度是否未填充满，不满则设置到$(window).height()。


Iframe 用法
1. 用来实现长连接，在websocket不可用的时候作为一种替代，最开始由google发明。Comet：基于 HTTP 长连接的“服务器推”技术（基于iframe和htmlfile的流方式，通过在html页面里嵌入一个隐藏iframe，将这个iframe的src属性设置为对一个长连接的请求，服务器端就能源源不断地往客户端输入数据。数据并不返回直接显示在页面的数据，而是返回对客户端JS函数的调用，来自服务器端的数据作为JS函数的参数传递，客户端浏览器的JS引擎在收到服务器返回的JS调用时就会去执行代码。一个不足，页面一直是加载进行中，解决办法，使用一个称为htmlfile的ActiveX解决IE加载显示问题。）
        
        How? By cleverly abusing another safe-for-scripting ActiveX control in IE. Here’s the basic structure of the hack:
        --------------------------------------------------------------
        // we were served from child.example.com but 
        // have already set document.domain to example.com
        var currentDomain = "http://exmaple.com/"; 
        var dataStreamUrl = currentDomain+"path/to/server.cgi";
        var transferDoc = new ActiveXObject("htmlfile"); // !?!
        // make sure it's really scriptable
        transferDoc.open();
        transferDoc.write("<html>");
        transferDoc.write("<script>document.domain='"+currentDomain+"';</script>");
        transferDoc.write("</html>");
        transferDoc.close();
        // set the iframe up to call the server for data
        var ifrDiv = transferDoc.createElement("div");
        transferDoc.appendChild(ifrDiv);
        // start communicating
        ifrDiv.innerHTML = "<iframe src='"+dataStreamUrl+"'></iframe>";
        ----------------------------------------------------------------
        This is the kind of fundamental technique that is critical to making the next generation of interactive experiences a reality.

2. 跨域通信。JavaScript跨域总结与解决办法 ，类似的还有浏览器多页面通信，比如音乐播放器，用户如果打开了多个tab页，应该只有一个在播放。
3. 历史记录管理，解决ajax化网站响应浏览器前进后退按钮的方案，在html5的history api不可用时作为一种替代。
4. 纯前端的utf8和gbk编码互转。比如在utf8页面需要生成一个gbk的encodeURIComponent字符串，可以通过页面加载一个gbk的iframe，然后主页面与子页面通信的方式实现转换，这样就不用在页面上插入一个非常巨大的编码映射表文件了， 把这个iframe部署到父页面的同源服务上，就能在父页面直接调用iframe中的encoding接口了。

        <!doctype html>
        <html>
        <head>
            <meta charset="gbk">
            <script>
            window.encoding = function(str){
                //利用a元素的href属性来encode
                var a = document.createElement("a");
                a.href = "/?q=" + str;
                var url = a.href; //这里读取的时候会自动编码
                a.href = "/?q=";
                return url.replace(a.href, "");
            };
            </script>
        </head>
        </html>


5. 用iframe实现无刷新文件上传，在FormData不可用时作为替代方案
6. 在移动端用于从网页调起客户端应用（此方法在iphone上并不安全，慎用！具体风险看这里  iOS URL Scheme 劫持 ）。比如想在网页中调起支付宝，我们可以创建一个iframe，

        src为：alipayqr://platformapi/startapp?saId=10000007&clientVersion=3.7.0.0718&qrcode={支付二维码扫描的url}

浏览器接收到这个url请求发现未知协议，会交给系统处理，系统就能调起支付宝客户端了。我们还能趁机检查一下用户是否安装客户端：给iframe设置一个3-5秒的css3的transition过渡动画，然后监听动画完成事件，如果用户安装了客户端，那么系统会调起，并将浏览器转入后台运行，进入后台的浏览器一般不会再执行css动画，这样，我们就能通过判断css动画执行的时长是否超过预设来判断用户是否安装某个客户端了

        /**
        * 调起客户端
        * @param url {String}
        * @param onSuccess {Function}
        * @param onFail {Function}
        */
        module.exports = function(url, onSuccess, onFail){
            // 记录起始时间
            var last = Date.now();

            // 创建一个iframe
            var ifr = document.createElement('IFRAME');
            ifr.src = url;
            // 飘出屏幕外
            ifr.style.position = 'absolute';
            ifr.style.left = '-1000px';
            ifr.style.top = '-1000px';
            ifr.style.width = '1px';
            ifr.style.height = '1px';
            // 设置一个4秒的动画用于检查客户端是否被调起
            ifr.style.webkitTransition = 'all 4s';
            document.body.appendChild(ifr);
            setTimeout(function(){
                // 监听动画完成时间
                ifr.addEventListener('webkitTransitionEnd', function(){
                    document.body.removeChild(ifr);
                    if(Date.now() - last < 6000){
                        // 如果动画执行时间在预设范围内，就认为没有调起客户端
                        if(typeof onFail === 'function'){
                            onFail();
                        }
                    } else if(typeof onSuccess === 'function') {
                        // 动画执行超过预设范围，认为调起成功
                        onSuccess();
                    }
                }, false);
                // 启动动画
                ifr.style.left = '-10px';
            }, 0);
        };

7. 创建一个全新的独立的宿主环境。iframe还可以用于创建新的宿主环境，用于隔离或者访问原始接口及对象，比如有些前端安全的防范会覆盖一些原生的方法防止恶意调用，那我们就能通过创建一个iframe，然后从iframe中取回原始对象和方法来破解这种防范。javascript裸对象创建中的一种方法：如何创建一个JavaScript裸对象 ，一般所见即所得编辑器也是由iframe创建的.
8. IE6下用于遮罩select。经 @yaniv 提醒想起来的。曾经在ie6时代，想搞一个模态窗口，如果窗口叠加在select元素上面，是遮不住select的，为了解决这个问题，可以通过在模态窗口元素下面垫一个iframe来实现遮罩，好坑爹的ie6.



HTML规范说：The iframe element represents a nested browsing context.所以如果你需要独立的浏览上下文，那么就用 iframe，否则就不用。
历史上，iframe 常被用于复用部分界面，但是多数情况下并不合适。现在，应该使用 iframe 的例子如：
  1. 沙箱隔离。
  2. 引用第三方内容。
  3. 独立的带有交互的内容，比如幻灯片。
  4. 需要保持独立焦点和历史管理的子窗口，如复杂的Web应用。注：登录弹窗用 iframe 未必合适。HTML标准新增了dialog元素，可能更适合

完全隔离的css 和 js , 但又可以使用 contentWindow和parent 来通信. 松耦合又不失灵活
* 隔离上下文网页,
* 打开一个网页加载过多iframe体验很不友好而且影响网页加载速度。


iframe用于隔离父-子页面和提供特殊的布局格式，想上中下格式的没必要用iframe  目前最多的是XX系统管理类似的网站，左边一个菜单list，右边就是iframe的tabs，可以随时打开关闭页面，对于系统管理真的很方便，这种系统，如果把iframe替换成DIV，那么大量页面中的相同类型的表格，表单等就要用不同的ID，CLASS，因为你的JS是针对BODY下的所有对象的，所以这种系统用IFRAME比较好，可以再IFRAME里面自由使用JS和标签的ID定义，而且父页面和菜单列表一般不会刷新，所以IFRAME带来的内容也就和一般页面的刷新一样。   

还有关于IFRAME缓存的问题，这个问题太严重了，调试的时候经常会出现编辑器保存了，但是IFRAME里面的表单内容没有变，
* 解决办法就是IFRAME的SRC属性的URL地址后面加一个随机数，每次刷新IFRAME就都是不同的URL，那么IFRAME就会去刷新了。

1. 方便插入第三方内容，不担心影响整体页面加载，例如联盟广告
2. 缓存网页，主要是在网络不好的时候
3. postMessage通信
4. 安全沙箱，避免污染环境
5. 流量作弊，嵌入一个不展现的iframe页面，反作弊很难发现

