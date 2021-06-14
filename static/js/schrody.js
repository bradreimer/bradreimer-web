/*
  bradreimer.ca by Brad Reimer
*/

// Increment hello counter
async function sayHello(name) {
  const response = await fetch('/api/sayHello', {
    method: 'POST',
    body: {
      'name': name
    },
    headers: {
      'Content-Type': 'application/json'
    }
  });
  const text = await response.text();
  return text
}

$(function() {
  $("#fletch").on("click", async function() {
    document.getElementById("fletch").innerHTML = await sayHello("Fletch");
    return false;
  });

  $("#fibs").on("click", async function() {
    document.getElementById("fibs").innerHTML = await sayHello("Fibs");
    return false;
  });
})
