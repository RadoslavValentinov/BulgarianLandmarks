function set(){


    let getValue = document.getElementById("FieldToSearch").value;
    let resultValue = document.getElementById("result");

    resultValue.textContent = getValue;

    /*$Url.Action("Search", "Home", new { item = getValue.ToString() });*/


}