using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using WMPLib; //미디어 플레이어 라이브러리, 최초 프로젝트시 참조에 추가 (COM의 Windows Media Player)

namespace MP3_SAMPLE
{
    public partial class frm_mp3player : Form
    {
        private List<string> listFileFullPaths = new List<string>(); //파일절대경로를 저장하기 위한 리스트
        private WindowsMediaPlayer windowsMediaPlayer = new WindowsMediaPlayer();

        private int playFileNum = 0; //현재 재생중인 미디어번호
        private bool playStatus = false; //플레이 상태
        private Timer playTimer = new Timer(); //다음곡 자동재생용 타이머

        public frm_mp3player()
        {
            InitializeComponent();

            btn_addMedia.Click += Btn_addMedia_Click; //mp3 파일을 열기위한 버튼이벤트
            btn_play.Click += Btn_play_Click; //mp3파일을 재생하기위한 버튼이벤트
            btn_stop.Click += Btn_stop_Click; //mp3파일을 정지하기위한 버튼이벤트

            windowsMediaPlayer.PlayStateChange += WindowsMediaPlayer_PlayStateChange; //mediaplayer의 play state가 변경되면 발생하는 이벤트

            playTimer.Enabled = true;
            playTimer.Stop();
            playTimer.Tick += PlayTimer_Tick;
        }

        private void PlayTimer_Tick(object sender, EventArgs e)
        {
            playTimer.Stop();
            playFileNum++; //미디어번호 1 증가

            if (playFileNum >= lbx_playlist.Items.Count) //리스트에 저장된 갯수를 넘으면 다시 0번부터 재생
            {
                playFileNum = 0;
            }

            lbx_playlist.SetSelected(playFileNum, true);
            windowsMediaPlayer.URL = lbx_playlist.SelectedItem.ToString();
            windowsMediaPlayer.controls.play();
        }

        //mediaplayer의 play state가 변경되면 발생하는 이벤트
        //NewState가 Stopped일때(노래가 끝날때) 다음곡 자동재생하기위해 추가

        private void WindowsMediaPlayer_PlayStateChange(int NewState)
        {
            switch (NewState)
            {
                case 0:    // Undefined
                    break;

                case 1:    // Stopped
                    if (playStatus == true)
                    {
                        if (lbx_playlist.Items.Count > 0)
                        {
                            playTimer.Start(); //다음곡 재생
                        }
                    }
                    break;

                case 2:    // Paused
                    break;

                case 3:    // Playing
                    break;

                case 4:    // ScanForward
                    break;

                case 5:    // ScanReverse
                    break;

                case 6:    // Buffering
                    break;

                case 7:    // Waiting
                    break;

                case 8:    // MediaEnded
                    break;

                case 9:    // Transitioning
                    break;

                case 10:   // Ready
                    break;

                case 11:   // Reconnecting
                    break;

                case 12:   // Last
                    break;

                default:
                    break;
            }
        }

        //mp3 파일을 열기위한 버튼이벤트
        private void Btn_addMedia_Click(object sender, EventArgs e)
        {

            //파일열기
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = Environment.CurrentDirectory + "\\mp3"; //최초에 열리는 폴더경로(실행파일 위치의 mp3폴더)
                openFileDialog.Filter = "mp3 files (*.mp3)|*.mp3"; //파일 필터 설정
                openFileDialog.Multiselect = true; //파일 다중선택

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    foreach (string path in openFileDialog.FileNames)
                    {
                        if (listFileFullPaths.FindIndex(data => data.Contains(path)) == -1) //중복된 파일인지 확인
                        {
                            lbx_playlist.Items.Add(path); //중복되지 않았으면 리스트에 저장
                        }
                    }
                }
            }

        }

        //mp3파일을 재생하기위한 버튼이벤트
        private void Btn_play_Click(object sender, EventArgs e)
        {
            playStatus = true;

            if (lbx_playlist.SelectedItem != null)
            {
                playFileNum = lbx_playlist.SelectedIndex; //현재 재생할 mp3의 index값
                windowsMediaPlayer.URL = lbx_playlist.SelectedItem.ToString();
                windowsMediaPlayer.controls.play();
            }
            else
            {
                MessageBox.Show("재생할 음악을 선택해 주십시오");
            }
        }

        //mp3파일을 정지하기위한 버튼이벤트
        private void Btn_stop_Click(object sender, EventArgs e)
        {
            playStatus = false;
            //음악이 재생중이면 정지
            if(windowsMediaPlayer.playState == WMPPlayState.wmppsPlaying)
            {
                windowsMediaPlayer.controls.stop();
            }
        }


    }
}
