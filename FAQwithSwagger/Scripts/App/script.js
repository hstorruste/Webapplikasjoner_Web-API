$(document).ready(function () {
    $('.nav').children('li').children('a').click(function () {
        $(this).parent().parent().children('li').removeClass("active");
        $(this).parent().addClass("active");
    });

    $('a[href="/FAQ"]').click(function () {
        $('.nav').children('li').removeClass("active");
        $('.nav').find('a[href="/FAQ"]').parent().addClass("active");
    });
});

function kontaktScript() {
    $('[data-toggle="tooltip"]').tooltip();
    $('a[href="/FAQ"]').click(function () {
        $('.nav').children('li').removeClass("active");
        $('.nav').find('a[href="/FAQ"]').parent().addClass("active");
    });
}