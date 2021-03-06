## EventAction
class in Actionkit / Inherits from:[NodeAction](ActionKitAPI/Action/NodeAction.md) / Implemented in : [IPoolable](www.baidu.com)

## Description
事件节点，存储多个事件

## Implemented Properties
* IsRecycled        缓存标记

## Inherits Methods

* Finish			      结束当前节点，

* Break                              设置节点的状态为Finish

* Reset                              重置节点状态

* public bool Execute(float dt)     执行当前节点，需要传入执行一次的时间，返回是否执行结束


  | 参数 | 描述           |
  | ---- | -------------- |
  | dt   | 执行一次的时间 |

* Dispose                          设置节点的状态为Dispose

## Public Methods
*  public static EventAction Allocate(params System.Action[] onExecuteEvents)		从```缓存池```中获取事件节点


| 参数            | 描述     |
| --------------- | -------- |
| onExecuteEvents | 多个事件 |

## Messages
* OnRecycled	     	 回收缓存时回调
* OnDispose			节点销毁时回调，这里用于```缓存池```回收该节点
* OnExecute			执行节点回调，这里直接发出当前```事件```。
