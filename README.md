# LRU缓存
刷`leetcode`每日一题，记录一下

## 思路分析
使用哈希表解决查找和插入`O(1)`的问题  
使用双向链表解决缓存热度  
结合下就是哈希链表（#233）

## 实现过程
在实现的过程中，大部分时间花费在边界的处理，想砸键盘

## 巧用伪元素来减少编码的复杂度
看了`leetcode`的官方解读，觉得自己还是太年轻

## 伪元素
创建首尾伪元素，在链表操作时可以忽略边界处理，下面列出部分代码，可以查看完整[代码实现](/src/LRUCache/LRUCache.cs)
``` C#
/// <summary>
/// 伪首元素，可以忽略边界处理
/// </summary>
private readonly DoubleLinkedListNode _first = new DoubleLinkedListNode(default, default);

/// <summary>
/// 伪尾元素，可以忽略边界处理
/// </summary>
private readonly DoubleLinkedListNode _last = new DoubleLinkedListNode(default, default);

... 其它元素

private void AddFirst(DoubleLinkedListNode node)
{
    node.prev = _first;
    node.next = _first.next;
    _first.next.prev = node;
    _first.next = node;
}

... 其它元素
```
