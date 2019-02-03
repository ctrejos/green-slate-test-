window.onload = getUsers;

function getUsers() {

  var items;
  $.get("/ProjectManagement/GetUserList/")
    .done(function (data) {
      $.each(data,
        function (key, val) {
          for(var i= 0; i < val.length; i++ )
            {
                items += "<option value='" + val[i].ID + "'>" + val[i].FirstName + "</option>";
            }
        });
      var header = '<option value=\'\'>Select...</option>';
      $('#userList').html(header + items);
    });
}

function getDate(date) {
    if (date !== undefined) {
      var newdate = date.replace('/Date(', '');
      newdate = newdate.replace(')/', '');
      newdate = new Date(parseInt(newdate));
        return formatDate(newdate);
    }
}

function formatDate(date) {
    var monthNames = [
        "January", "February", "March",
        "April", "May", "June", "July",
        "August", "September", "October",
        "November", "December"
    ];

    var day = date.getDate();
    var monthIndex = date.getMonth();
    var year = date.getFullYear();

    return day + ' ' + monthNames[monthIndex] + ' ' + year;
}


function onUserchanged() {
  var Parent = document.getElementById("projectList");
    while (Parent.hasChildNodes()) {
        Parent.removeChild(Parent.firstChild);
  }

  var userId = document.getElementById("userList").value;
  var table = $("#projectList");
  table.append("<tr>  <th> Project Id</th > <th>Start Date</th>  <th>Time to start</th> <th>End date</th> <th>Credits</th> <th>Status</th></tr >");
  $.get("/ProjectManagement/GetProjectByUserID/", { userId: userId})
        .done(function (data) {
            $.each(data,
              function (key, val) {

                for (var i = 0; i < val.length; i++) {
                  
                    table.append(
                          "<tr><td>" +
                          val[i].ProjectId +
                          "</td><td>" +
                      getDate(val[i].StartDate) +
                          "</td>   <td>" +
                      val[i].TimeToStart +
                          "</td>   <td>" +
                          getDate(val[i].EndDate) +
                          "</td>   <td>" +
                      val[i].Credits +
                          "</td>   <td>" +
                      val[i].Status +
                          "</td></tr>");
                  }
              });
        });

}