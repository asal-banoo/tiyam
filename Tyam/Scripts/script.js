$(function () {
    if (!window.weAreHome) {
        $('#top-nav').each(function () {
            this.style.setProperty('background-color', '#FF3636', 'important');
        });
    }
    $('select').niceSelect();
    $('#category').change(function () {
        $("#loading").fadeIn();
    })
})