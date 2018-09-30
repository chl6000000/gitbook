## Dockerfile
用于编写docker镜像生成过程的文件。

>在此文件夹下执行命令：`docker build --tag name:tag .`, 

>就可以按照描述构建一个镜像。 `name` 是镜像的名字，`tag` 是镜像的版本或标签号，默认是`lastest`, 注意后面有一个空格和点。

Dockerfile的语法
* 基本指令: FROM, MAINTAINER, RUN, CMD, EXPOSE, ENV, ADD, COPY, ENTRYPOINT, VOLUME, USER, WORKDIR, ONBUILD

> FROM `<image>`

>> 第一个指令必须是FROM, 指定一个构建镜像的基础源镜像，如果本地没有就会从公共库中拉取。

> MAINTAINER `<name>` `<email>`

>> 描述镜像的创建者，名称和邮箱

> RUN `"command" "param1" "param2"`

> CMD `command param1 param2`

> EXPOSE `<port> [<port> ...]`

> ENV

>> ENV `<key> <value>` 只能设置一个

>> ENV `<key>=<value>` 允许一次设置多个

> ADD  `<src> <dest>`

> COPY `<src> <dest>`

> ENTRYPOINT `"command" "param1" "param2"`

> VOLUME `["path"]`

> USER `daemon`

> WORKDIR `path`

> ONBUILD `[instruction]`

