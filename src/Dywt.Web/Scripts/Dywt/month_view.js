
$(function () {
    function getClassForAnswer(answer) {
        if (answer === 'True') {
            return 'worked';
        }
        else if (answer === 'False') {
            return 'away';
        }
        return 'unknown';
    }

    function getNextAnswer(currentAnswer) {
        if (currentAnswer === 'True') {
            return 'False';
        }
        else if (currentAnswer === 'False') {
            return '';
        }
        return 'True';
    }

    function getTextForAnswer(answer) {
        if (answer === 'True') {
            return 'Yes';
        }
        else if (answer === 'False') {
            return 'No';
        }
        return '&nbsp;';
    }

    var monthView = $('body.month.index');

    monthView.on({
        click: function (e) {
            e.preventDefault();

            var anchor = $(this);
            var paragraph = anchor.find('p');
            var parent = anchor.parent();

            var currentAnswer = anchor.data('current-answer');
            var currentClass = getClassForAnswer(currentAnswer);

            var newAnswer = getNextAnswer(currentAnswer);
            var newClass = getClassForAnswer(newAnswer);

            var url = anchor.attr('href');

            var requestPending = monthView.data('request-pending');

            if (!requestPending) {
                monthView.data('request-pending', true);
                $.post(url, { DidYouWork: newAnswer })
                    .done(function () {
                        parent.removeClass(currentClass).addClass(newClass);
                        anchor.data('current-answer', newAnswer);
                        paragraph.html(getTextForAnswer(newAnswer));
                    })
                    .always(function () {
                        monthView.data('request-pending', false);
                    });
            }
        }
    }, 'li > a');
});
