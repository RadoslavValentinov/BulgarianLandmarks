function set(){


    let getValue = document.getElementById("FieldToSearch").value;

    $Url.Action("Search", "Home", new { item = getValue.ToString() });

}