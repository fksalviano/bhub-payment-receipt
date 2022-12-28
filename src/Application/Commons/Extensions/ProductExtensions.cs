using Application.Commons.Domain;
using Application.Commons.MailSender.Domain;

namespace Application.Commons.Extensions;

public static class ProductExtensions
{
    // TODO: call a builder to build the tutorial video mail based on product video and tutorial

    public static Mail GetVideoTutorialMail(this Product product) => new Mail("test", "test",
        $"This is the tutorial video {product.Video?.TutorialVideo?.Title} for video {product.Video?.Title}");
}