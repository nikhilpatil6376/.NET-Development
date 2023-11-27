using System;

public struct Student
{
    //Fields
    private int _ID;


    //Properties
    public int ID
    {
        get
        {
            return this._ID;
        }

        set
        {
            if (value > 0)
            {
                this._ID = value;
            }
        }
    }
    public string Name { get; set; }
    public int Age { get; set; }

    //Costructor
    public Student(int ID,string Name,int Age)
    {
        this._ID = ID;
        this.Name = Name;
        this.Age = Age;
    }

    //Methods
    public void Print()
    {
        Console.WriteLine("Id:{0} Name:{1} Age:{2}",this._ID,this.Name,this.Age);
    }
}


public struct StructureDemo
{
    public static void Main(string[] args)
    {
        Student st= new Student(1,"Nikhil",21);
        st.Print();
    }
}