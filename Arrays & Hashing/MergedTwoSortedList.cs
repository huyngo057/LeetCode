namespace LeetCode;

public class MergedTwoSortedList
{
    public class ListNode
    {
        public int value;
        public ListNode? next;

        public ListNode(int value = 0, ListNode? next = null)
        {
            this.value = value;
            this.next = next;
        } 
    }
    
    public ListNode MergeTwoLists(ListNode list1, ListNode list2)
    {
        return new ListNode();
    }
    
    [Theory]
    [InlineData(new[] { 1, 2, 4 }, new[] { 1, 3, 4 })]
    public void Test(int[] list1Values, int[] list2Values)
    {
        var list1 = GenerateLinkedList(list1Values);
        var list2 = GenerateLinkedList(list2Values);
        var result = list1Values.Concat(list2Values).Distinct().OrderBy(x => x).ToArray();
        var actualResult = new List<int>();
        if (list1 != null && list2 != null)
        {
            var listNode = MergeTwoLists(list1, list2);
            while (listNode != null)
            {
                actualResult.Add(listNode.value);
                listNode = listNode.next;
            }
        }
        Assert.NotEmpty(actualResult);
        Assert.Equal(result, actualResult);
    }

    public ListNode? GenerateLinkedList(int[] values)
    {
        if (values.Length == 0)
        {
            return null;
        }

        ListNode head = new ListNode(values[0]);
        ListNode current = head;

        for (int i = 1; i < values.Length; i++)
        {
            current.next = new ListNode(values[i]);
            current = current.next;
        }

        return head;
    }
}