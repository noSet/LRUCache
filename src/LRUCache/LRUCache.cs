using System.Collections.Generic;

namespace LRUCache
{
    public class LRUCache
    {
        private class DoubleLinkedListNode
        {
            public int key;
            public int val;
            public DoubleLinkedListNode prev;
            public DoubleLinkedListNode next;

            public DoubleLinkedListNode(int key, int val)
            {
                this.key = key;
                this.val = val;
            }
        }

        /// <summary>
        /// 伪首元素，可以忽略边界处理
        /// </summary>
        private readonly DoubleLinkedListNode _first = new DoubleLinkedListNode(default, default);

        /// <summary>
        /// 伪尾元素，可以忽略边界处理
        /// </summary>
        private readonly DoubleLinkedListNode _last = new DoubleLinkedListNode(default, default);

        private readonly Dictionary<int, DoubleLinkedListNode> _cache;
        private readonly int _capacity;
        private int _count;

        public LRUCache(int capacity)
        {
            _count = 0;
            _capacity = capacity;
            _cache = new Dictionary<int, DoubleLinkedListNode>(capacity);

            _first.next = _last;
            _last.prev = _first;
        }

        public int Get(int key)
        {
            if (!_cache.TryGetValue(key, out var node))
            {
                return -1;
            }

            MoveFirst(node);
            return node.val;
        }

        public void Put(int key, int value)
        {
            DoubleLinkedListNode node;

            if (_cache.TryGetValue(key, out node))
            {
                node.val = value;
                MoveFirst(node);
                return;
            }

            node = new DoubleLinkedListNode(key, value);

            _cache.Add(key, node);

            AddFirst(node);

            _count++;

            if (_count > _capacity)
            {
                DoubleLinkedListNode removeNode = RemoveLast();
                _cache.Remove(removeNode.key);
                _count--;
            }
        }

        private void AddFirst(DoubleLinkedListNode node)
        {
            node.prev = _first;
            node.next = _first.next;
            _first.next.prev = node;
            _first.next = node;
        }

        private void Remove(DoubleLinkedListNode node)
        {
            node.prev.next = node.next;
            node.next.prev = node.prev;
        }

        private void MoveFirst(DoubleLinkedListNode node)
        {
            Remove(node);
            AddFirst(node);
        }

        private DoubleLinkedListNode RemoveLast()
        {
            DoubleLinkedListNode node = _last.prev;
            Remove(node);

            return node;
        }
    }
}
