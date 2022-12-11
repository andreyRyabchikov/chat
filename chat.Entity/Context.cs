using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using chat.Entity.Models;

namespace chat.Entity;
public class Context : IdentityDbContext<User, UserRole, Guid>
{
    public Context(DbContextOptions<Context> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        #region Users

        builder.Entity<User>().ToTable("users");
        builder.Entity<User>().HasKey(x => x.Id);

        builder.Entity<IdentityUserClaim<Guid>>().ToTable("user_claims");
        builder.Entity<IdentityUserLogin<Guid>>().ToTable("user_logins");
        builder.Entity<IdentityUserToken<Guid>>().ToTable("user_tokens");
        builder.Entity<UserRole>().ToTable("user_roles");
        builder.Entity<IdentityRoleClaim<Guid>>().ToTable("user_role_claims");
        builder.Entity<IdentityUserRole<Guid>>().ToTable("user_role_owners");

        #endregion

        #region BlackList

        builder.Entity<BlackList>().ToTable("blackLists");
        builder.Entity<BlackList>().HasKey(x => x.Id);
        builder.Entity<BlackList>().HasOne(x => x.User)
                                    .WithMany(x => x.ThemBanned)
                                    .HasForeignKey(x => x.IdUser)
                                    .OnDelete(DeleteBehavior.Restrict);     
        builder.Entity<BlackList>().HasOne(x => x.UserBlocked)
                                    .WithMany(x => x.ThatBanned)
                                    .HasForeignKey(x => x.IdUserBlocked)
                                    .OnDelete(DeleteBehavior.Restrict);
                       

        #endregion

        #region Contact

        builder.Entity<Contact>().ToTable("contacts");
        builder.Entity<Contact>().HasKey(x => x.Id);
        builder.Entity<Contact>().HasOne(x => x.User)
                                    .WithMany(x => x.ThemContacts)
                                    .HasForeignKey(x => x.IdUser)
                                    .OnDelete(DeleteBehavior.Restrict);     
        builder.Entity<Contact>().HasOne(x => x.UserContact)
                                    .WithMany(x => x.ThatContacts)
                                    .HasForeignKey(x => x.IdUserContact)
                                    .OnDelete(DeleteBehavior.Restrict);

        #endregion

        #region Chat

        builder.Entity<Chat>().ToTable("chats");
        builder.Entity<Chat>().HasKey(x => x.Id);

        #endregion

        #region ChatMembers

        builder.Entity<ChatMember>().ToTable("chatMembers");
        builder.Entity<ChatMember>().HasKey(x => x.Id);
        builder.Entity<ChatMember>().HasOne(x => x.User)
                                    .WithMany(x => x.ChatMembers)
                                    .HasForeignKey(x => x.IdUser)
                                    .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<ChatMember>().HasOne(x => x.Chat)
                                    .WithMany(x => x.ChatMembers)
                                    .HasForeignKey(x => x.IdChat)
                                    .OnDelete(DeleteBehavior.Cascade);

        #endregion

        #region Message

        builder.Entity<Message>().ToTable("messages");
        builder.Entity<Message>().HasKey(x => x.Id);
        builder.Entity<Message>().HasOne(x => x.User)
                                    .WithMany(x => x.Messages)
                                    .HasForeignKey(x => x.IdUser)
                                    .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<Message>().HasOne(x => x.Chat)
                                    .WithMany(x => x.Messages)
                                    .HasForeignKey(x => x.IdChat)
                                    .OnDelete(DeleteBehavior.Cascade);

        #endregion

        #region Attachments

        builder.Entity<Attachment>().ToTable("attachments");
        builder.Entity<Attachment>().HasKey(x => x.Id);
        builder.Entity<Attachment>().HasOne(x => x.Message)
                                    .WithMany(x => x.Attachments)
                                    .HasForeignKey(x => x.IdMessage)
                                    .OnDelete(DeleteBehavior.Cascade);

        #endregion
    }
}
