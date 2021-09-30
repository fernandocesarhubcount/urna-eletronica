 
$(document).ready(function() {
 
 
  var $IdnomeCandidato = $("#IdnomeCandidato");
  var $IdnomeViceCandidato = $("#IdnomeViceCandidato");
  var $CodigoCandidato = $("#CodigoCandidato");
  var $inputLegenda = $("#inputLegenda"); 
  
  $( "#btnSalvar" ).click(function(e){
    e.preventDefault();
    if( $IdnomeCandidato.val()=='' ||  
        $IdnomeViceCandidato.val()=='' ||  
        $CodigoCandidato.val()=='' ||
        $inputLegenda.val()==''){ 
      swal("Aviso", "Campo não pode ficar vazio", "error");
    }else{
      SalvarCandidato();
    } 
  });

  function SalvarCandidato(){
    
    now = new Date();
    var formData = new FormData();
    var dataISOAnoMes =  now.getFullYear()+"-"+now.getMonth()+"-"+now.getDay();
    
    formData.append('CodigoCandidato', $CodigoCandidato.val());
    formData.append('nomeCompleto', $IdnomeCandidato.val());
    formData.append('nomeVice', $IdnomeViceCandidato.val());
    formData.append('dataRegistro', dataISOAnoMes);
    formData.append('legenda', $inputLegenda.val());  

    var url = "https://localhost:44378/Candidato" ;
    var xhr = new XMLHttpRequest();  
    
    xhr.open('POST', url,true); 
    xhr.onload = function() {
        if(xhr.status == 200) {
          resertCampo(); 
        }else if(xhr.status == 400){
          swal("Aviso", "Candidato inválido", "error");
        }
    }
    xhr.send(formData);
  }


  function resertCampo(){ 
    $IdnomeCandidato.val('');     
    $IdnomeViceCandidato.val('');
    $CodigoCandidato.val('');
    $inputLegenda.val('');
    swal("Aviso", "Candidato cadastrado com sucesso!", "success");
  }


 
});
 