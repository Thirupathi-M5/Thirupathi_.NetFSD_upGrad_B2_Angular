// Get button
const button = document.getElementById("themeBtn");

// Load saved theme from localStorage
const savedTheme = localStorage.getItem("theme");

if (savedTheme === "dark") {
  document.body.classList.add("dark-mode");
}

// Toggle theme function
const toggleTheme = () => {

  document.body.classList.toggle("dark-mode");

  // Save theme
  if (document.body.classList.contains("dark-mode")) {
    localStorage.setItem("theme", "dark");
  } else {
    localStorage.setItem("theme", "light");
  }
};

// Event listener
button.addEventListener("click", toggleTheme);