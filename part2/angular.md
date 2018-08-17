# Angular Concept

## AngularJS 应用架构,单页面应用， 
### html元素包含AngularJS应用(ng-app=) 
### html页面元素定义了 控制器的作用域(ng-controller=), 
>一个应用可以有多个控制器 AngularJS在HTML DOMContentLoaded事件中自动开始， 如果找到ng-app指令，AngularJS载入指令中的模块，并将ng-app 作为应用的根进行编译。 应用的根可以是整个页面，或者页面的一小部分（更快的编译，执行）

>>ng-model指令绑定了 textarea 到控制器变量message. 

>>ng-click事件调用了控制器函数 clear() ng-bind指令绑定控制器函数 到 元素

## Dependency Injection 一个或更多的依赖（或服务)被注入（或通过引用传递）到一个独立的对象（客户端）中，然后成为该客户端状态的一部分。 
>该模式分离了客户端依赖本身行为的创建，这使得程序设计变得松耦合，并遵循依赖反转和单一职责原则。 与服务定位模式形成直接对比的是，它允许客户端了解客户端如何使用该系统找到依赖。


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


