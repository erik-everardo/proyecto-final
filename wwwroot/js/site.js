var stColor = true; //true: normal false:oscuro

function cambiarModoColor(){
    if(stColor){ //cambiar a modo oscuro
        document.getElementById('barra').className = "navbar navbar-expand-lg navbar-dark bg-dark sticky-top";
        document.getElementById('boton-modo-color').className = "fas fa-sun";
        document.body.style.backgroundColor = "rgb(43,43,43)";
        document.body.style.color = "white";
        document.getElementById('modo-luz').className = "btn btn-dark";
        document.getElementById('boton-modo-color').style.color = "white";
        document.getElementById('footer').style.backgroundColor = "#343a40";
        document.getElementById('footer').style.color = "white";
        stColor = false;
    }else{
        document.getElementById('barra').className = "navbar navbar-expand-lg navbar-light bg-light sticky-top";
        document.body.style.backgroundColor = "white";
        document.body.style.color = "black";
        document.getElementById('boton-modo-color').className = "fas fa-moon";
        document.getElementById('modo-luz').className = "btn btn-light";
        document.getElementById('boton-modo-color').style.color = "black";
        document.getElementById('footer').style.backgroundColor = "#f8f9fa";
        document.getElementById('footer').style.color = "black";
        stColor = true;
    }
}