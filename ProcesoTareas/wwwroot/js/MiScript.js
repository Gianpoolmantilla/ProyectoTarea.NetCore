function confirmBorrar(Id, seHizoClick) {
    var confirmBorrar = 'BorrarSpan_' + Id;
    var confirmBorrarSpan = 'confirmBorrarSpan_' + Id;

    if (seHizoClick) {
        $('#' + confirmBorrar).hide();
        $('#' + confirmBorrarSpan).show();
    } else {
        $('#' + confirmBorrar).show();
        $('#' + confirmBorrarSpan).hide();
    }
}