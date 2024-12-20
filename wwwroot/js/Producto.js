
function ShowConfirmAcction(evt,id)
{
    evt.preventDefault();

    
    Swal.fire({
        title: "Quieres salvar cambios?",
        showDenyButton: true,
        showCancelButton: true,
        confirmButtonText: "Confirmo",
        denyButtonText: `Cancelar`
    }).then((result) => {
        /* Read more about isConfirmed, isDenied below */
        if (result.isConfirmed)
        {
            window.location.href = '/producto/Edit/${id}';
            Swal.fire("Saved!", "", "success");
        } else if (result.isDenied) {
            Swal.fire("Changes are not saved", "", "${id}");
        }
    });

}

