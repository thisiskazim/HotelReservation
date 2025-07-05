// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(function () {
    $('.datetimepicker-input').each(function () {
        // Her bir inputun bağlı olduğu datetimepicker container'ını alıyoruz
        // (örneğin, data-target="#date3" attribute'ünden)
        var $input = $(this);
        var targetSelector = $input.attr('data-target');

        if (targetSelector) {
            // Eğer bu target üzerinde daha önce datetimepicker yoksa başlat
            var $target = $(targetSelector);

            // Eğer target element zaten datetimepicker ile başlatılmamışsa
            if (!$target.data('datetimepicker')) {
                $target.datetimepicker({
                    format: 'DD/MM/YYYY',
                    icons: {
                        time: 'fa fa-clock',
                        date: 'fa fa-calendar',
                        up: 'fa fa-arrow-up',
                        down: 'fa fa-arrow-down',
                        previous: 'fa fa-chevron-left',
                        next: 'fa fa-chevron-right',
                        today: 'fa fa-calendar-check-o',
                        clear: 'fa fa-trash',
                        close: 'fa fa-times'
                    }
                });
            }
        }
    });
});
