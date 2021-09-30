 
$(document).ready(function() {
 
  obterVotosCandidatos();
  function obterVotosCandidatos(){ 

    var url = "https://localhost:44378/Vote" ;
    var xhr = new XMLHttpRequest();
    xhr.open("GET", url, true); 
    xhr.onload = function () { 
      if(xhr.status == 200){ 
        var response = JSON.parse(this.response);  
         
        var table = document.getElementById("listCandidato");

        for (var i = 1; i <= response.length; i++) { 
          var row = table.insertRow(i);
        
          var cell0 = row.insertCell(0);
          var cell1 = row.insertCell(1);
          var cell2 = row.insertCell(2);
          var cell3 = row.insertCell(3);
          var cell4 = row.insertCell(4);
          var cell5 = row.insertCell(5);
      
          cell0.innerHTML = response[i-1].totalVotos ;
          cell1.innerHTML = response[i-1].codigoCandidato;
          cell2.innerHTML = response[i-1].nomeCompleto;
          cell3.innerHTML = response[i-1].nomeVice ;
          cell4.innerHTML = response[i-1].dataRegistro;
          cell5.innerHTML = response[i-1].legenda; 
           
        }
      } 
    }
    xhr.send();
  }  
  
  
  

});
 