$(document).ready(function()
{
    $('#mostrarPassword').click(function()
    {
       if($(this).hasClass('fa-eye'))
       {
           $('#password').removeAttr('type');
           $('#mostrarPassword').addClass('fa-eye-slash').removeClass('fa-eye');
       }
       else
       {
           //Establecemos el atributo y valor
           $('#password').attr('type','password');
           $('#mostrarPassword').addClass('fa-eye').removeClass('fa-eye-slash');
       }
    });
});