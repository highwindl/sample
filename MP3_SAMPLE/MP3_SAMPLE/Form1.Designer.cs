namespace MP3_SAMPLE
{
    partial class frm_mp3player
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_addMedia = new System.Windows.Forms.Button();
            this.btn_play = new System.Windows.Forms.Button();
            this.lbx_playlist = new System.Windows.Forms.ListBox();
            this.btn_stop = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_addMedia
            // 
            this.btn_addMedia.Location = new System.Drawing.Point(12, 12);
            this.btn_addMedia.Name = "btn_addMedia";
            this.btn_addMedia.Size = new System.Drawing.Size(75, 23);
            this.btn_addMedia.TabIndex = 0;
            this.btn_addMedia.Text = "파일추가";
            this.btn_addMedia.UseVisualStyleBackColor = true;
            // 
            // btn_play
            // 
            this.btn_play.Location = new System.Drawing.Point(93, 12);
            this.btn_play.Name = "btn_play";
            this.btn_play.Size = new System.Drawing.Size(75, 23);
            this.btn_play.TabIndex = 1;
            this.btn_play.Text = "재생";
            this.btn_play.UseVisualStyleBackColor = true;
            // 
            // lbx_playlist
            // 
            this.lbx_playlist.FormattingEnabled = true;
            this.lbx_playlist.HorizontalScrollbar = true;
            this.lbx_playlist.ItemHeight = 12;
            this.lbx_playlist.Location = new System.Drawing.Point(12, 41);
            this.lbx_playlist.Name = "lbx_playlist";
            this.lbx_playlist.Size = new System.Drawing.Size(588, 304);
            this.lbx_playlist.TabIndex = 2;
            // 
            // btn_stop
            // 
            this.btn_stop.Location = new System.Drawing.Point(174, 12);
            this.btn_stop.Name = "btn_stop";
            this.btn_stop.Size = new System.Drawing.Size(75, 23);
            this.btn_stop.TabIndex = 3;
            this.btn_stop.Text = "정지";
            this.btn_stop.UseVisualStyleBackColor = true;
            // 
            // frm_mp3player
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 361);
            this.Controls.Add(this.btn_stop);
            this.Controls.Add(this.lbx_playlist);
            this.Controls.Add(this.btn_play);
            this.Controls.Add(this.btn_addMedia);
            this.Name = "frm_mp3player";
            this.Text = "MP3 Player";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_addMedia;
        private System.Windows.Forms.Button btn_play;
        private System.Windows.Forms.ListBox lbx_playlist;
        private System.Windows.Forms.Button btn_stop;
    }
}

