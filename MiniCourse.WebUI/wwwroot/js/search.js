function goDetail(courseId) {

    var url = `/courses/detail/${courseId}`;
    window.location.href = url;
}

$('#headerSearch').on('input', function () {

    $('.spinnerSearch').addClass('d-block');
    $('.spinnerSearch').removeClass('d-none');
    var searchText = $(this).val();
    console.log(searchText)
    if (searchText.length > 0) {

        $.ajax({
            url: '/Courses/SearchCourse',
            method: 'Post',
            data: { searchValue: searchText },
            success: function (response) {
                var courses = response.data;
                console.log(courses)
                $('#courseSearchResult').empty();

                if (response.isValid && response.data.length > 0) {
                    $('.spinnerSearch').addClass('d-none');
                    $('.spinnerSearch').removeClass('d-block');
                    $.each(courses, function (index, course) {

                        $("#courseSearchResult").append(
                            `
                               <div class="container my-4">
                                <div class="row align-items-center border rounded shadow-sm p-3">
                                    <!-- Kurs Resmi -->
                                    <div class="col-md-4 col-12 text-center">
                                        <img src="/img/${course.courseImage}" alt="Kurs Resmi" class="img-fluid rounded">
                                    </div>
                                    <!-- Kurs Bilgileri -->
                                    <div class="col-md-8 col-12">
                                        <h5 class="text-dark mb-2">${course.title}</h5>
                                        <p class="text-muted mb-0">
                                            ${course.description}
                                        </p>
                                        <a href="javascript:void(0);" onclick="goDetail(${course.id})" class="btn btn-outline-dark mt-3">Detaylı Bilgi</a>
                                    </div>
                                </div>
                            </div>
                            `);
                    });
                } else {

                    $('.spinnerSearch').addClass('d-none');
                    $('.spinnerSearch').removeClass('d-block');
                    $('#courseSearchResult').empty();
                    $('#courseSearchResult').append('<div class="movie"><h5 class="py-3 card-title text-center">Sonuc Bulunamadi</h5></div>');
                }
            },
            error: function (xhr, status, error) {
            }
        });
    } else {
        $('.spinnerSearch').addClass('d-none');
        $('.spinnerSearch').removeClass('d-block');
        $('#courseSearchResult').empty();
    }
});