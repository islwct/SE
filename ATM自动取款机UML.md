## ATM自动取款机

#### 1.用例图

ATM自动取款机业务系统主要有两个执行者：银行管理者和客户。

银行管理者启动或参与的业务主要有添加现金，维护ATM硬件设备和协助客户改密码。用户启动或参与的业务主要有修改密码，取款，存款，缴费，转账和查询余额。

![image](https://github.com/islwct/SE/edit/main/img/1.png)

2.类图

银行ATM设计类类图描述了不同类之间的关系，以及说明类有何种属性和操作。该系统可以为用户提供“存款”，“取款”、“转账”、“缴费”、“查询余额”和“修改密码”等操作，为银行职员提供添加现金，维护ATM硬件设备和协助客户改密码的操作，这些操作都需要与ATM发生信息交互。

| 类名       | 功能                                                | 属性                                                         | 操作说明                                                     | 关系说明                                   |
| ---------- | --------------------------------------------------- | ------------------------------------------------------------ | ------------------------------------------------------------ | ------------------------------------------ |
| 用户       | 记录人员信息和基本操作                              | +姓名：string<br/>+账户id：long<br/>- 密码：私有，string     | +登录（）：boolean<br/>+修改密码（）：boolean<br/>           | 被客户类和银行管理员类所继承               |
| 客户       | 主要存储客户的个人信息和账户信息                    | +姓名：string<br/>+账户id：long<br/>- 密码：私有，string     | +取款（）：boolean<br/>+存款（）：boolean<br/>+转账（）：boolean<br/>+查询（）：boolean<br/>+修改密码（）：boolean<br/>+登录（）：boolean | 与用户类为继承关系                         |
| 银行管理员 | 主要存储管理员个人信息和工作记录                    | +姓名：string<br/>+账户id：long<br/>- 密码：私有，string     | +添加现金（）：boolean<br/>+修改密码（）：boolean<br/>+维护ATM硬件设备（）：boolean | 与用户类为继承关系                         |
| ATM机      | 记录ATM机的机器信息和交易金额、时间、地点等信息     | +编号：long<br/>+归属银行：string<br/>- 纸币数目：私有       | +读取银行卡信息（）：boolean<br/>+取款业务（）：boolean<br/>+存款业务（）：boolean<br/>+转账业务（）：boolean<br/>+查询业务（）：boolean<br/>+修改密码处理（）：boolean<br/>+缴费业务（）：boolean<br/>+打印凭证业务（）：boolean<br/>+维护记录（）：boolean | 与客户、银行管理员、银行数据库类为聚合关系 |
| 银行数据库 | 记录ATM所属银行信息和所有用户信息，保存所有交易记录 | +银行名称：string<br/>+银行地址：string<br/>-银行账户集：私有，string<br/>-ATM编号集：私有，long | +添加用户（）：boolean<br/>+删除用户（）：boolean<br/>+记录操作记录（）：boolean<br/>+删除操作记录（）：boolean | 与ATM机关联                                |

![image](https://github.com/islwct/SE/edit/main/img/2类图.png)

3.对象图

对象图可以看作是类图的实例

![image](https://github.com/islwct/SE/edit/main/img/3对象图.drawio.png)

4.活动图

客户插入信用卡后，ATM系统运行了三个并发的活动：验证卡、验证PIN(密码)和验证余额。三个验证都结束之后，ATM系统根据这三个验证的结果来执行下一步的活动。卡正常、密码正确且通过余额验证，则ATM系统接下来询问客户有哪些要求也就是要执行什么操作。若验证卡、验证PIN(密码)和验证余额这三个验证有任一个通不过的话，ATM系统就把相应的出错信息在ATM屏幕上。

![image](https://github.com/islwct/SE/edit/main/img/4活动.png)

5.状态图

当结余小于0时，客户发出请求取钱，透支通知客户；客户请求关闭状态变为close,或者检查结余小于0达到30天以上状态也变为close。

![image](https://github.com/islwct/SE/edit/main/img/5zhuangtai.png)

6.序列图

客户把卡插入读卡机开始，读卡机读卡号，初始化ATM屏幕，并打开账目对象。屏幕提示输入PIN，客户输入PIN，屏幕验证PIN与账目对象，发出相符的信息。屏幕向客户提供选项，客户选择取钱，然后屏幕提示输入金额，客户选择金额。然后屏幕从账目中取钱，启动一系列账目对象要完成的过程。首先，验证账目中金额是否足够；然后，它从中扣钱，再让取钱机提供现金，最后客户让读卡机退卡。

![image](https://github.com/islwct/SE/edit/main/img/6.png)

7.协作图

协作图显示的信息和序列图是相同的，只是协作图用不同的方式显示而已。序列图显示的是对象和参与者随时间变化的交互，而协作图则不参照时间而显示对象与参与者的交互。

![image](https://github.com/islwct/SE/edit/main/img/7xiezuo.png)

8.构件图

读卡机与显示类相关，有显示类才能编译读卡机类，编译所有类后，可以创建可执行文件ATM.exe。每个类有自己的体文件和头文件，如显示类映射ATM显示组件，阴影组件表示显示类的体文件（.cpp）
![image](https://github.com/islwct/SE/edit/main/img/8.png)

9.部署图

ATM客户机通过专用网与地区ATM服务器通信，ATM服务器的可执行文件在地区ATM服务器上执行，地区ATM服务器通过专用网与银行数据库服务器通信。


![image](https://github.com/islwct/SE/edit/main/img/9bu.png)
