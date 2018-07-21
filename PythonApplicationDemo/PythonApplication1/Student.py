class Student(object):
    """description of class"""
    def __init__(self, name, age, markC, markHTML, markJava):
        self.StudentName=name
        self.StudentAge=age
        self.MarkC=markC
        self.MarkHTML=markHTML
        self.MarkJava=markJava
        self.TotalMark=str(float(markC)+float(markHTML)+float(markJava))
        #return super().__init__(**kwargs)
    
    def display(self):
        str = "Student Name: " +self.StudentName + "\n" \
        "Student Age: " +self.StudentAge + "\n" \
        "Mark C: " +self.MarkC + "\n" \
        "Mark HTML: " +self.MarkHTML + "\n" \
        "Mark Java: " +self.MarkJava + "\n" \
        "Total Mark: " +self.TotalMark + "\n" \
        
    
        return str

    
    

        
        

