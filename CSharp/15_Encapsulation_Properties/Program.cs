using System;

class Student
{
    private int _Id;
    private int _PassMark;
    private string _Password;

    public int Id //Read and Write Property
    {
        get
        {
            return this._Id;
        }
        set
        {
            if (value > 0)
            {
                this._Id = value;
            }
        }
    }

    public int PassMark  //Read only Property
    {
        get
        {
            this._PassMark = 80;
            return this._PassMark;
        }
    }

    public string Password  //Write only Property
    {
        set
        {
            this._Password = value;
        }
    }

    public string Name { get; set; } //Auto Implement Property

}
public class Properties
{
    public static void Main(string[] args)
    {
        Student st = new Student();
        st.Id = 1;
        st.Name = "Nikhil";
        st.Password = "123";
        //st.PassMark = 99; CompileTime Error

        Console.WriteLine("Id:{0} Name:{1} PassMark:{2}", st.Id, st.Name, st.PassMark);
        //Console.WriteLine("Id:{0} Name:{1} PassMark:{2} Password:{3}", st.Id, st.Name, st.PassMark,st.Password);
    }
}