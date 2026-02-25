// Select elements
const input = document.getElementById("taskInput");
const addBtn = document.getElementById("addBtn");
const taskList = document.getElementById("taskList");

/* -------------------- */
/* Add Task Function     */
/* -------------------- */
const addTask = () => {

  const taskText = input.value.trim();

  if (taskText === "") return;

  const li = document.createElement("li");

  li.innerHTML = `
    <span class="task-text">${taskText}</span>
    <button class="complete-btn">✔</button>
    <button class="delete-btn">✖</button>
  `;

  taskList.appendChild(li);

  input.value = "";
};

/* -------------------- */
/* Event Delegation      */
/* -------------------- */
taskList.addEventListener("click", (e) => {

  // Delete task
  if (e.target.classList.contains("delete-btn")) {
    e.target.parentElement.remove();
  }

  // Mark complete
  if (e.target.classList.contains("complete-btn")) {
    const text = e.target.parentElement.querySelector(".task-text");
    text.classList.toggle("completed");
  }

});

/* -------------------- */
/* Add button event      */
/* -------------------- */
addBtn.addEventListener("click", addTask);