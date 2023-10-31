//$(document).ready(function () {
//    $("#tableRole").DataTabel();
//})
let table = new DataTable('#tableRole');
function Delete(id) {
    Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
        if (result.isConfirmed) {
            window.location.href = `/Admin/Accounts/DeleteRole?id=${id}`,
            Swal.fire(
                'Deleted!',
                'Your file has been deleted.',
                'success'
            )
        }
    })
}

Edit = (id, name) => {
    document.getElementById("roleId").value = id;
    document.getElementById("roleName").value = name;
    document.getElementById("btnSave").value = 'تعديل';
    document.getElementById("title").innerHTML = 'تعديل مجموعة المستخدم';
}
Rest = () => {
    document.getElementById("roleId").value = '';
    document.getElementById("roleName").value = '';
    document.getElementById("btnSave").value = 'حفظ';
    document.getElementById("title").innerHTML = 'اضف مجموعة جديدة';
}