/*
  bradreimer.ca by Brad Reimer
*/

// Increment hello counter
function sayHello(name) {
  console.log("Hello: " + name);
  return 42;
}

$(function() {
  $("#fletch").on("click", function() {
    var count = sayHello("Fletch");
    document.getElementById("fletch").innerHTML = `<strong>Hello human!</strong> ${count} people have said hello to me.`
    return false;
  });

  $("#fibs").on("click", function() {
    var count = sayHello("Fibs");
    document.getElementById("fibs").innerHTML = `<strong>Hello human!</strong> ${count} people have said hello to me.`
    return false;
  });
})
