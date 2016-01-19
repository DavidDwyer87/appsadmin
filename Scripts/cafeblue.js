$(document).ready(function (e) {
});

//set mode for modal view
function setMode(data)
{
    $('#proCat').val(data);
    findProduct();
}

//validate the new form for all products
function validateNewForm()
{
    //set '-' to  and price field that is blank.
    if ($('#smallprice').val() == '')
    {
        $('#smallprice').val('-');
    }
    else if ($('#medprice').val() == '')
    {
        $('#medprice').val('-');
    }
    else if ($('#largeprice').val() == '')
    {
        $('#largeprice').val('-')
    }

    //check if these below field are blank.
    if($('#ProductName').val() =='')
    {
        alert('Product name cant be blank.');
        $('#ProductName').focus();
    }
    else if($('#Description').val() =='')
    {
        alert('Description is required field');
        $('#Description').focus();
    }
    else //submit new product form
    {
        $('#newProdform').submit();
    }
}

//display the image to upload on new product form
function setpreview()
{
    var loc = $('#file').val();
    $('#preView').attr('src', loc);
}

//check if product exist
function validateProductName()
{    
    $.ajax({
       type: 'POST',
       url: '/Meal/NameStatus/?name=' + $('#ProductName').val()+"&cati="+$('#proCat').val(),
       cache: false,
       success: function (data) {
           if (data == true) {
               alert('Product name already exist!');
               $('#ProductName').focus();
           }
       }
   });
}

//find product for manage product modal window
function findProduct()
{
    $.ajax({
        type: 'POST',
        url: '/Meal/ManageProduct/?productName=' + $('#prodOption').val() + "&cati=" + $('#proCat').val(),
        cache: false,
        success: function (data) {
            $('#productName_manage').val(data.ProductName);
            $('#smallprice_manage').val(data.smallprice);
            $('#medprice_manage').val(data.medprice);
            $('#largeprice_manage').val(data.largeprice);
            $('#description_manage').val(data.Description);
        }
    });
}

//remove products from inventory
function validateDelete()
{
    alert('yes');
    if($('#prod').val() != $('#prodname').val())
    {
        alert('name of the product dont match');
    }
    else
    {
        $.ajax({
            type: 'POST',
            url: '/Meal/RemoveProd/?name=' + $('#prodname').val() + "&cati=" + $('#proCat').val(),
            cache: false,
            success: function (data) {
                location.reload();
            }
        });        
    }
}