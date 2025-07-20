// Full code for Form1.cs
// Remember to install the `Confluent.Kafka` NuGet package.

using System;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Confluent.Kafka;

namespace KafkaChatApp
{
    public partial class Form1 : Form
    {
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.RichTextBox rtbChatHistory;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Label lblUsername;

        private IProducer<Null, string> kafkaProducer;
        private CancellationTokenSource consumerTokenSource;

        // --- Configuration ---
        private const string KafkaTopic = "chat-topic";
        private const string KafkaBootstrapServers = "localhost:9092";

        public Form1()
        {
            InitializeComponent();
            InitializeKafka();
            StartConsumer();
        }

        private void InitializeKafka()
        {
            var producerConfig = new ProducerConfig { BootstrapServers = KafkaBootstrapServers };
            this.kafkaProducer = new ProducerBuilder<Null, string>(producerConfig).Build();
        }

        private void StartConsumer()
        {
            var consumerConfig = new ConsumerConfig
            {
                BootstrapServers = KafkaBootstrapServers,
                GroupId = "chat-app-group-" + Guid.NewGuid(), // Unique group ID for each instance to get all messages
                AutoOffsetReset = AutoOffsetReset.Earliest
            };

            this.consumerTokenSource = new CancellationTokenSource();

            // Run the consumer in a background thread to avoid blocking the UI
            Task.Run(() =>
            {
                using (var consumer = new ConsumerBuilder<Ignore, string>(consumerConfig).Build())
                {
                    consumer.Subscribe(KafkaTopic);
                    try
                    {
                        while (!consumerTokenSource.Token.IsCancellationRequested)
                        {
                            try
                            {
                                var consumeResult = consumer.Consume(consumerTokenSource.Token);
                                // Handle the message on the UI thread
                                this.Invoke(new Action(() =>
                                {
                                    AppendMessageToChatHistory(consumeResult.Message.Value);
                                }));
                            }
                            catch (ConsumeException e)
                            {
                                // Handle consumer error
                                this.Invoke(new Action(() =>
                                {
                                    AppendMessageToChatHistory($"[Error] {e.Error.Reason}");
                                }));
                            }
                        }
                    }
                    catch (OperationCanceledException)
                    {
                        // Cancellation was requested
                    }
                    finally
                    {
                        consumer.Close();
                    }
                }
            }, consumerTokenSource.Token);
        }

        private void AppendMessageToChatHistory(string message)
        {
            if (rtbChatHistory.Text.Length > 0)
            {
                rtbChatHistory.AppendText(Environment.NewLine);
            }
            rtbChatHistory.AppendText(message);
            rtbChatHistory.ScrollToCaret();
        }

        private async void btnSend_Click(object sender, EventArgs e)
        {
            var username = txtUsername.Text.Trim();
            var message = txtMessage.Text.Trim();

            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Please enter a username.", "Username Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(message))
            {
                return; // Don't send empty messages
            }

            var fullMessage = $"{username} [{DateTime.Now:HH:mm:ss}]: {message}";

            try
            {
                // Asynchronously send the message to the Kafka topic
                await this.kafkaProducer.ProduceAsync(KafkaTopic, new Message<Null, string> { Value = fullMessage });
                txtMessage.Clear();
                txtMessage.Focus();
            }
            catch (ProduceException<Null, string> ex)
            {
                MessageBox.Show($"Failed to deliver message: {ex.Error.Reason}", "Kafka Produce Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Clean up resources
            if (this.kafkaProducer != null)
            {
                this.kafkaProducer.Flush(TimeSpan.FromSeconds(10));
                this.kafkaProducer.Dispose();
            }
            if (this.consumerTokenSource != null)
            {
                this.consumerTokenSource.Cancel();
                this.consumerTokenSource.Dispose();
            }
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.rtbChatHistory = new System.Windows.Forms.RichTextBox();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.lblUsername = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtUsername
            // 
            this.txtUsername.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUsername.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsername.Location = new System.Drawing.Point(90, 12);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(482, 25);
            this.txtUsername.TabIndex = 0;
            // 
            // rtbChatHistory
            // 
            this.rtbChatHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbChatHistory.BackColor = System.Drawing.Color.White;
            this.rtbChatHistory.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbChatHistory.Location = new System.Drawing.Point(12, 43);
            this.rtbChatHistory.Name = "rtbChatHistory";
            this.rtbChatHistory.ReadOnly = true;
            this.rtbChatHistory.Size = new System.Drawing.Size(560, 356);
            this.rtbChatHistory.TabIndex = 4;
            this.rtbChatHistory.Text = "";
            // 
            // txtMessage
            // 
            this.txtMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMessage.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMessage.Location = new System.Drawing.Point(12, 405);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(479, 25);
            this.txtMessage.TabIndex = 1;
            // 
            // btnSend
            // 
            this.btnSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSend.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSend.Location = new System.Drawing.Point(497, 405);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 25);
            this.btnSend.TabIndex = 2;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsername.Location = new System.Drawing.Point(12, 15);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(72, 17);
            this.lblUsername.TabIndex = 3;
            this.lblUsername.Text = "Username:";
            // 
            // Form1
            // 
            this.AcceptButton = this.btnSend;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 441);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.rtbChatHistory);
            this.Controls.Add(this.txtUsername);
            this.MinimumSize = new System.Drawing.Size(400, 300);
            this.Name = "Form1";
            this.Text = "Kafka Chat";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        #endregion
    }
}
