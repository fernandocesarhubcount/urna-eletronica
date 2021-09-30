 
$(document).ready(function() {
 
  var $btnNumber = $('.btn-number');
  var $bt = $(".btn");
  var $dezena = $(".input-dezena");
  var $unidade = $(".input-unidade");
  var $btnBranco = $('.btn-branco');
  var $btnConfirma = $('.btn-confirma');
  var $btnCorrige = $('.btn-corrige');  
  var $nomeCandidatoVice = $('.nome-canditato-vice');
  var $nomeCandidatoPresidente = $('.nome-canditato-presidente');  
  var $partidoCandidato = $('.partido-candidato'); 
  var $fim = $('#fim');
  
  
   if( ($dezena.val()=="") && ($unidade.val()=="") ){
     $btnNumber.click(function(e){
      e.preventDefault();
       var $valor = $(this).text();
        if($dezena.val()==''){
          $dezena.val($valor);
        }else if( ($dezena.val()!='') && ($unidade.val()=='') ){
          $unidade.val($valor);
        }
    });
  }
  

  $btnNumber.click(function(e){
    e.preventDefault();
    $('#tecla')[0].play();
    if( ($dezena.val() != '') && ($unidade.val() != '') ){ 
     var idCandidato =$dezena.val() + $unidade.val() ;
       pesquisarCandidatos(idCandidato);
    }
  });
  
  $btnCorrige.click(function(e){
    e.preventDefault();
    $('#tecla')[0].play();
    $('input').val('');
    $bt.removeAttr('disabled');
    $btnBranco.removeAttr('disabled'); 
  });
  
  $btnBranco.click(function(e){
    e.preventDefault();
    $('#tecla')[0].play();
    $dezena.val('-');
    $unidade.val('-');
    $nomeCandidatoPresidente.val('voto em branco');
    $nomeCandidatoVice.val('voto em branco');
    $partidoCandidato.val('voto em branco');
    $btnNumber.attr("disabled", 'disabled');    
  });
    
  $btnConfirma.click(function(e){
    e.preventDefault();
    if( ($dezena.val()!="")){
       
       if( ($dezena.val()=='-') && ($unidade.val()=='-')  ){ 
        SalvarVotoNullo();
      } else if( ($dezena.val()!='-') && ($unidade.val()!='-')  ){ 
        SalvarVoto();
      }

    }
  });

  function SalvarVoto(){
    now = new Date();
    var formData = new FormData();
    var dataISOAnoMes =  now.getFullYear()+"-"+now.getMonth()+"-"+now.getDay();
    var idCandidato =$dezena.val() + $unidade.val() ;
    
    formData.append('Datavoto', dataISOAnoMes);
    formData.append('CodigoCandidato', idCandidato);
  
    var url = "https://localhost:44378/Vote" ;
    var xhr = new XMLHttpRequest();  
    
    xhr.open('POST', url,true); 
    xhr.onload = function() {
        if(xhr.status == 200) {
          resertUrna(); 
        }else if(xhr.status == 400){
          swal("Aviso", "Candidato inválido", "error");
        }
    }
    xhr.send(formData);
  }

  function SalvarVotoNullo(){
    now = new Date();
    var formData = new FormData();
    var dataISOAnoMes =  now.getFullYear()+"-"+now.getMonth()+"-"+now.getDay();
    
    formData.append('Datavoto', dataISOAnoMes);
    formData.append('CodigoCandidato', "");
  
    var url = "https://localhost:44378/Vote" ;
    var xhr = new XMLHttpRequest();  
    
    xhr.open('POST', url,true); 
    xhr.onload = function() {
        if(xhr.status == 200) {
          resertUrna(); 
        }else if(xhr.status == 400){
          swal("Aviso", "Candidato inválido", "error");
        }
    }
    xhr.send(formData);
  }
   
  function resertUrna(){
      $fim.show();
      $bt.attr("disabled", 'disabled');
      setTimeout(function(){
        $fim.hide();
        $bt.removeAttr('disabled');
        $('input').val(''); 
      }, 5000);
      $('#confirma')[0].play(); 
  }
  function pesquisarCandidatos(idCandidato){ 

    var url = "https://localhost:44378/Candidato/" +idCandidato;
    var xhr = new XMLHttpRequest();
    xhr.open("GET", url, true); 
    xhr.onload = function () { 
      if(xhr.status == 400){ 
        swal("Aviso", "Candidato não encontrado na base de dados", "error");
        $dezena.val('');
        $unidade.val('');  
      }else{
        var response = JSON.parse(this.response); 
        $nomeCandidatoPresidente.val(response[0]['nomeCompleto']);
        $nomeCandidatoVice.val(response[0]['nomeVice']);
        $partidoCandidato.val(response[0]['codigoCandidato']);    
      }
    }
    xhr.send();
}  

function obterVotosCandidatos(idCandidato){ 

  var url = "https://localhost:44378/Vote" ;
  var xhr = new XMLHttpRequest();
  xhr.open("GET", url, true); 
  xhr.onload = function () { 
    if(xhr.status == 200){ 
      var response = JSON.parse(this.response); 
      $nomeCandidatoPresidente.val(response[0]['nomeCompleto']);
      $nomeCandidatoVice.val(response[0]['nomeVice']);
      $partidoCandidato.val(response[0]['codigoCandidato']);     
    } 
  }
  xhr.send();
}  

   

});
 