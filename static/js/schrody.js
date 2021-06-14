/*
  bradreimer.ca by Brad Reimer
*/

// Increment hello counter
async function sayHello(name) {
  const body = { name : name };
  const response = await fetch('/api/sayHello', {
    method: 'POST',
    body: JSON.stringify(body),
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
