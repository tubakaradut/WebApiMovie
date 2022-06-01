//rastgele film gelmesi için method
function GetRandomMovie() {
    $.ajax({
        method: 'Get',
        url: '/api/movies/GetRandomMovie'
    }).done(function (randommovies) {
        var tr = `<tr>
                    <td>${randommovies.Id}</td>
                    <td>${randommovies.Title}</td>
                    <td>${randommovies.Description}</td>
                    <td>${randommovies.Rating}</td>
                    <td>${randommovies.Year}</td>
                    </tr>`
        $("#movieTable").empty().append(tr);
    })
}

//rastgele puanı 70den fazla olan filmin gelmesi için method
function GetRandomHighRatingMovie() {
    $.ajax({
        method: 'Get',
        url: '/api/movies/GetRandomHighRatingMovie'
    }).done(function (randomHighRatingMovie) {
        var tr = `< tr >
                    <td>${randomHighRatingMovie.Id}</td>
                    <td>${randomHighRatingMovie.Title}</td>
                    <td>${randomHighRatingMovie.Description}</td>
                    <td>${randomHighRatingMovie.Rating}</td>
                    <td>${randomHighRatingMovie.Year}</td>
                    </tr >`
        $("#movieTable").empty().append(tr);
    })
}

//Arama yapmak tekrar bakılacak  sadece bir tanesini getiriyor

//function Search() {

//    var result = document.getElementById('txtAra').value;
//    $.ajax({
//        method: 'Get',
//        url: '/api/movies/'+result
//    }).done(function (movies) {
//        console.log(movies.count)
//        for (var i = 0; i < movies.length; i++) {
//            var tr = `< tr >
//                    <td>${movies[i].Id}</td>
//                    <td>${movies[i].Title}</td>
//                    <td>${movies[i].Description}</td>
//                    <td>${movies[i].Rating}</td>
//                    <td>${movies[i].Year}</td>
//                    </tr >`
//            $("#movieTable").empty().append(tr);
//        }
//    })
//}

function Search() {

    $("#txtAra").on("keyup", function () {
        var value = $(this).val().toLowerCase();
        $("#movieTable tr").filter(function () {
            $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
        });
    });
}

// Arama methodunun acıklaması:Giriş alanının değeriyle eşleşen herhangi bir metin değeri olup olmadığını kontrol etmek için her tablo satırında döngü yapmak için jQuery kullanıyoruz. Yöntem , aramayla eşleşmeyen toggle()satırı ( ) gizler . Metni küçük harfe dönüştürmek için DOM yöntemini kullanırız, bu da aramanın büyük/küçük harfe duyarlı olmamasını sağlar.



//filmlerin listelenmesi
$(document).ready(function () {
    $.ajax({
        method: 'Get',
        url: '/api/movies/getmovies'
    }).done(function (movies) {
        for (var i = 0; i < movies.length; i++) {
            var tr = `
                    <tr>
                    <td>${movies[i].Id}</td>
                    <td>${movies[i].Title}</td>
                    <td>${movies[i].Description}</td>
                    <td>${movies[i].Rating}</td>
                    <td>${movies[i].Year}</td>
                    </tr>
                    `
            $("#movieTable").append(tr);
        }
    })


    //rastgele film gelmesi
    $('#btnRandom').click(function () {
        GetRandomMovie();
    });


    //rastgele puanı 70den fazla olan filmin gelmesi
    $('#btnRandomHighRatingMovie').click(function () {
        GetRandomHighRatingMovie();
    });


    //arama yapmak

    $('#txtAra').keyup(function () { Search() });

})
