let student = {
  name: "Thiru",
  rollNo: 155,
  marks: 75
};


function updateStudentProfile(studentObj) {

  let profileDiv = document.getElementById("profileBox");

  profileDiv.innerHTML =
    "Name: " + studentObj.name + "<br>" +
    "Roll No: " + studentObj.rollNo + "<br>" +
    "Marks: " + studentObj.marks;
}


function updateMarks(newMarks) {
  student.marks = newMarks;   // update object
  updateStudentProfile(student);  // refresh display
}

// Event listeners
document.getElementById("showBtn").addEventListener("click", function () {
  updateStudentProfile(student);
});

document.getElementById("updateBtn").addEventListener("click", function () {
  updateMarks(90);   
});