# Angular Concept

## AngularJS 应用架构,单页面应用， 
### html元素包含AngularJS应用(ng-app=) 
### html页面元素定义了 控制器的作用域(ng-controller=), 
>一个应用可以有多个控制器 AngularJS在HTML DOMContentLoaded事件中自动开始， 如果找到ng-app指令，AngularJS载入指令中的模块，并将ng-app 作为应用的根进行编译。 应用的根可以是整个页面，或者页面的一小部分（更快的编译，执行）

>>ng-model指令绑定了 textarea 到控制器变量message. 

>>ng-click事件调用了控制器函数 clear() ng-bind指令绑定控制器函数 到 元素

## Dependency Injection 一个或更多的依赖（或服务)被注入（或通过引用传递）到一个独立的对象（客户端）中，然后成为该客户端状态的一部分。 
>该模式分离了客户端依赖本身行为的创建，这使得程序设计变得松耦合，并遵循依赖反转和单一职责原则。 与服务定位模式形成直接对比的是，它允许客户端了解客户端如何使用该系统找到依赖。

## HTML attribute , DOM property
要理解Angular绑定如何工作，重点是搞清HTML Attribute和Dom property之间的区别
attribute defined by HTML, 
property defined by DOM(Document object model)
* few html attribute have mapping to property, example: id.
* some html attribute did not have related property, example: colspan.
* some dom property did not have related attribute, example: textContent.
* most of HTML attribute seems have mapping to property, but not what you think.

Take care: 
* attribute init Dom property, and property'value can be changed, but attribute'value cannot. 
* HTML'value , The initial value is specified via attribute, 
DOM'value, is property' current value. 

Angular的模板绑定是通过property和事件来工作的，而不是attribute(它的唯一作用是用来初始化元素和指令的状态). 

## 绑定目标
数据绑定的目标是DOM中的某些东西，这个目标可以是元素，组件，指令的 property/event等。

### 绑定类型： property, event,  双向，attribute(例外情况), css
* property binding: 当要把视图元素的属性设置为模板表达式时，就需要把元素属性设置为组件属性的值。
设置指令的属性
设置自定义组件的模型属性（这是父子组件之间通讯的重要途径）

把属性绑定描述成单向数据绑定，因为值的流动是单向的，从组件的数据属性流动到目标元素的属性。

不能使用属性绑定来从目标元素拉取值，也不能绑定到目标元素的属性来读取它。只能设置它。

## JavaScript module vs. NgModule
* JavaScript的模块是内含javascript代码的独立文件，可以为代码加上命名空间，防止全局变量污染。
    >写一个导出语句，外界即可调用 
    ```js
    export class AppComponent{...}
    ```
    >在其他文件需要这个文件时，写一个导入语句即可， 
    ```js
    import{AppComponent } from './app.component'
    ```
* NgModule 是带有@NgModule装饰器的类. @NgModule 装饰器的 imports 数组会告诉 Angular 哪些其它的 NgModule 是当前模块所需的。

    ```js
    @NgModule({
        declarations:[],
        imports:[],
        providers:[],
        bootstrap:[]
    })
    ```
### NgModule关键性不同点
* 只绑定了可声明类，只供Angular编译器用。
* 模块的类需要列在其@NgModule.declarations列表中
* 只能导出可声明类
* 可以通过把服务提供商加到@NgModule.providers列表中，用这些服务来扩展整个应用

## 引导启动

