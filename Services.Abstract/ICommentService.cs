using Contracts.CommentDto;

namespace Services.Abstract;

public interface ICommentService
{
    Task<CommentForCreationDto> CreateCommentAsync(Guid postId, Guid? parentCommentId = null,
        CancellationToken cancellationToken = default);

    Task<IEnumerable<CommentForReadDto>> GetCommentsByUsernameAsync(string username,
        CancellationToken cancellationToken = default);

    Task<IEnumerable<CommentForReadDto>>
        GetCommentsByPostId(Guid postId, CancellationToken cancellationToken = default);

    Task<IEnumerable<CommentForReadDto>> GetChildrenCommentsByIdCommentAsync(Guid commentId,
        CancellationToken cancellationToken = default);

    Task UpdateCommentByIdAsync(Guid commentId, CommentForUpdateDto commentForUpdate,
        CancellationToken cancellationToken = default);

    Task DeleteCommentByIdAsync(Guid commentId, CancellationToken cancellationToken = default);
}