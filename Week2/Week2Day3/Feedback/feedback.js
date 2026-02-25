// Get button element
const button = document.getElementById("feedbackBtn");

// Get paragraph element
const message = document.getElementById("message");

// Add click event
button.addEventListener("click", () => {
  message.innerText = "Feedback submitted successfully!";
});