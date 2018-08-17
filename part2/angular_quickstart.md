## [Angular 快速上手](https://angular.cn/guide/quickstart)
### 全局安装 Angular CLI

    npm install -g @angular/cli

### 创建新项目

    ng new my-app

### 启动开发服务器

    cd my-app
    ng serve --open

### 创建自定义组件

    ng generate component my_component

### 创建自定义服务

    ng generate service my_service --module=app

### 添加自定义模块

    ng generate module app-routing --flat --module=app
    // --flat: 生成的文件放在src/app下，不生成单独目录存放
    // --moudle：通知CLI把它注册到ＡppModule的import数组中

### 从npm安装需要的包

    //比如，安装内存Web API包的命令如下
    npm install angular-in-memory-web-api --save



