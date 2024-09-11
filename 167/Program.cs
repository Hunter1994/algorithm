
class Employee
{
    public int id;
    public int importance;
    public IList<int> subordinates;
}


class Solution
{
    public int GetImportance(IList<Employee> employees, int id)
    {
        Employee[] emps = new Employee[2001];
        foreach (var item in employees)
        {
            emps[item.id] = item;
        }
        return sum(emps, id);

    }
    private int sum(Employee[] emps, int i)
    {
        var res = emps[i].importance;
        foreach (var item in emps[i].subordinates)
        {
            res += sum(emps, item);
        }
        return res;
    }

}