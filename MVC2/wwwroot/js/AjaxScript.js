function ListAll() {
    $.get("Ajax/People", function (data, status) {
        $("#ajaxresult").html(data);
    });
}
function Details() {
    
    $.post("Ajax/Detail",
        {
            id: document.getElementById("personid").value
        }
        , function (data, status) {
        $("#ajaxresult").html(data);
   });
}
function Delete() {
    var a = document.getElementById("personid").value;
    $.post("Ajax/Delete",
        {
            id: a
        }
        , function (data, status) {
            
            if (data.status==404) {
                $("#ajaxresult").html("Person not found");
            }
            else {
                $("#ajaxresult").html("Person deleted");
            }
        });
}
