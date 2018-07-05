var myElement = document.getElementsByClassName("meatRows");
for (var i = 0; i < myElement.length; i++) {
    var secondColumnElements = (myElement[i].getElementsByTagName("td")[1].innerText);
    if (secondColumnElements < 20) {
        myElement[i].style.color = "red";
        myElement[i].style.fontWeight = "bold";
    }
}