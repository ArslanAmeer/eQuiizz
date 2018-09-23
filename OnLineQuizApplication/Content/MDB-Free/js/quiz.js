


console.log("Quiz JS File Connected Successfully");
var score = 0;
var point = 1;
var total = 5;
var highest = score * point;
function init() {
    sessionStorage.setItem('a1', 'b');
    sessionStorage.setItem('a2', 'd');
    sessionStorage.setItem('a3', 'c');
    sessionStorage.setItem('a4', 'a');
    sessionStorage.setItem('a5', 'b');

}

$(document).ready(function () {
    $('.question-form').hide();

    $('#q1').show();

    $('.question-form #submit').click(function () {
        current = $(this).parent('form:first').data('question');
        next = $(this).parent('form:first').data('question') + 1;
        $('.question-form').hide();
        $('#q' + next + '').fadeIn(300);
        process('' + current + '');
        return false;

    });




});
function process(q) {
    if (q === 'q1') {
        var submitted = $('input[name=q1]:checked').val();
        if (submitted === sessionStorage.a1) {
            score++;
        }
    }
    if (q === 'q2') {
        var submitted = $('input[name=q2]:checked').val();
        if (submitted === sessionStorage.a2) {
            score++;
        }
    }
    if (q === 'q3') {
        var submitted = $('input[name=q3]:checked').val();
        if (submitted === sessionStorage.a3) {
            score++;
        }
    }
    if (q === 'q4') {
        var submitted = $('input[name=q4]:checked').val();
        if (submitted === sessionStorage.a4) {
            score++;
        }
    }
    if (q === 'q5') {
        var submitted = $('input[name=q5]:checked').val();
        if (submitted === sessionStorage.a5) {
            score++;
        }
        $('#result').html("<h3>Your Final Score is" + score + "Out Of 5<h3><a href='@Url.Action('Layout','QuizHistory')'>Take Again this</a>");
    }
    return false;

}

window.addEventListener('load', init, false);















//$("#q1 #submit").click(function () {
//    $('.question-form').hide();
//    process('q1');
//    $('#q2').fadeIn(300);
//    return false;
//});
//$("#q2 #submit").click(function () {
//    $('.question-form').hide();
//    process('q2');
//    $('#q3').fadeIn(300);
//    return false;
//});
//$("#q3 #submit").click(function () {
//    $('.question-form').hide();
//    process('q3');
//    $('#q4').fadeIn(300);
//    return false;
//});
//$("#q4 #submit").click(function () {
//    $('.question-form').hide();
//    process('q4');
//    $('#q5').fadeIn(300);
//    return false;
//});
//$("#q5 #submit").click(function () {
//    $('.question-form').hide();
//    process('q5');
//    $('#result').fadeIn(300);
//    return false;
//});
