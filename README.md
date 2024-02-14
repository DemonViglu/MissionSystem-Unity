# 任务系统解析

## 核心部分： 数据部分 <a href="#MissionService">_MissionService_ </a>和UI部分<a href="#MissionUIManager"> _MissionUIManager_ </a>

## <a id="MissionService"> _MissionService_</a>

- 对于任务进行状态更新还是查询操作，所有执行方法都会在该类当中。

## <a id="MissionUIManager"> _MissionUIManager_ </a>

- 这个 _UIManager_ 主要对两个地方进行管控。一个是任务面板的绘制，另一个是成就小框的弹出。里面的绝大多数代码是对 _MissionService_ 的数据进行处理并绘制。只有少部分地方，比如 _Button_， 会对任务进行接取操作。但终归是调用 _MissionService_ 的api。