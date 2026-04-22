// Task storage
let tasks = [];

/* ---------------- CALLBACK VERSION ---------------- */

const addTaskCallback = (task, callback) => {
    setTimeout(() => {
        tasks.push(task);
        callback(`Task added: ${task}`);
    }, 1000);
};

const listTasksCallback = (callback) => {
    setTimeout(() => {
        callback(tasks);
    }, 1000);
};

/* ---------------- PROMISE VERSION ---------------- */

const addTaskPromise = (task) => {
    return new Promise((resolve) => {
        setTimeout(() => {
            tasks.push(task);
            resolve(`Task added: ${task}`);
        }, 1000);
    });
};

const listTasksPromise = () => {
    return new Promise((resolve) => {
        setTimeout(() => {
            resolve(tasks);
        }, 1000);
    });
};

/* ---------------- ASYNC/AWAIT VERSION ---------------- */

const runTasks = async () => {
    await addTaskPromise("Learn JS");
    await addTaskPromise("Practice Code");

    const allTasks = await listTasksPromise();

    console.log("Tasks List:");
    allTasks.forEach((task, index) => {
        console.log(`${index + 1}. ${task}`);
    });
};

/* ---------------- EXECUTION ---------------- */

// Callback demo
addTaskCallback("Task 1", (msg) => {
    console.log(msg);

    listTasksCallback((data) => {
        console.log("Callback Tasks:", data);
    });
});

// Async/Await demo
runTasks();